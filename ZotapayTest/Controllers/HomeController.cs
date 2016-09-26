using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Leverate.Zotapay;
using Leverate.Zotapay.Contract;
using Leverate.Zotapay.Web;
using ZotapayTest.Data;
using ZotapayTest.Models;
using ZotapayTest.Tools;

namespace ZotapayTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly Logger m_logger = new Logger(ConfigurationManager.AppSettings["LogsFolder"]);
        private readonly PaymentRepository m_paymentsRepository = new PaymentRepository(new PaymentsContext());

        // GET: Home
        public ActionResult Index(string message)
        {
            ViewBag.Message = message;

            var payments = m_paymentsRepository.Get();
            return View("Index", payments.ToList());
        }

        [HttpPost]
        public async Task<ActionResult> Deposit(decimal amount)
        {
            var endpointId = ConfigurationManager.AppSettings["EndpointId"];
            var endpointGroupId = ConfigurationManager.AppSettings["EndpointGroupId"];
            var merchantControl = ConfigurationManager.AppSettings["MerchantControl"];
            var siteUrl = ConfigurationManager.AppSettings["SiteUrl"];

            var flow = new PaymentFormFlow(merchantControl);

            var paymentFormRequest = flow.CreateEndpointPaymentFormRequest(
                endpointId: endpointId,
                clientOrderId: Guid.NewGuid().ToString().Substring(0, 8).ToUpperInvariant(),
                orderDescription: "Test Order Description",
                firstName: "John",
                lastName: "Smith",
                address: "100 Main st",
                city: "Seattle",
                state: "WA",
                zip: "98102",
                country: "US",
                phone: "+12063582043",
                email: "john.smith@gmail.com",
                amount: amount,
                currency: "USD",
                ipAddress: "65.153.12.232",
                redirectUrl: siteUrl);


            paymentFormRequest.ServerCallblackUrl = siteUrl + "Home/ProcessPayment";

            //paymentFormRequest.EndpointId = endpointId;
            //paymentFormRequest.ClientOrderId = Guid.NewGuid().ToString().Substring(0, 8).ToUpperInvariant();
            //paymentFormRequest.OrderDescription = "Test Order Description";
            //paymentFormRequest.FirstName = "John";
            //paymentFormRequest.LastName = "Smith";
            //paymentFormRequest.Ssn = "1267";
            //paymentFormRequest.Birthday = "19820115";
            //paymentFormRequest.Address = "100 Main st";
            //paymentFormRequest.City = "Seattle";
            //paymentFormRequest.State = "WA";
            //paymentFormRequest.Zip = "98102";
            //paymentFormRequest.Country = "US";
            //paymentFormRequest.Phone = "+12063582043";
            //paymentFormRequest.CellPhone = "+19023384543";
            //paymentFormRequest.Amount = amount;
            //paymentFormRequest.Email = "john.smith@gmail.com";
            //paymentFormRequest.Currency = "USD";
            //paymentFormRequest.IpAddress = "65.153.12.232";
            //paymentFormRequest.SiteUrl = siteUrl;
            //paymentFormRequest.RedirectUrl = siteUrl;
            //paymentFormRequest.ServerCallblackUrl = siteUrl + "Home/ProcessPayment";

            var paymentFormResponse = await flow.RequestPaymentForm(paymentFormRequest);

            if (string.IsNullOrEmpty(paymentFormResponse.RedirectUrl))
            {
                var errorMessage = string.Format("Payment failed: {0}", paymentFormResponse.ErrorMessage);
                return RedirectToAction("Index", new { message = errorMessage });
            }

            return Redirect(paymentFormResponse.RedirectUrl);
        }


        [HttpPost]
        public ActionResult Processing([ModelBinder(typeof (ZotapayModelBinder))] PaymentFormFinalRedirect result)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> ProcessPayment([ModelBinder(typeof(ZotapayModelBinder))] ReturnCallbackParameters result)
        {
            var payment = result.ToModel();

            m_paymentsRepository.Add(payment);
            m_paymentsRepository.SaveChanges();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}