using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Leverate.Zotapay.Infrastructure.Serializer;

namespace Leverate.Zotapay.Web
{
    public class ZotapayModelBinder : IModelBinder
    {
        private readonly FormSerializer m_serializer = new FormSerializer();

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            var formData = this.GetFormData(request);
            return m_serializer.Deserialize(bindingContext.ModelType, formData);
        }


        private string GetFormData(HttpRequestBase request)
        {
            if (request.HttpMethod == HttpMethod.Post.Method)
            {
                return request.Form.ToString();
            }
            else
            {
                return request.Url.Query;
            }
        }
    }
}
