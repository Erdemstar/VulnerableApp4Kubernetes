using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VulnerableApp4Kubernetes.Helper;

namespace VulnerableApp4Kubernetes.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VulnerableController : Controller
    {
        public GeneralHelper helper = new GeneralHelper();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RemoteCodeExecution(string Code)
        {
            return Ok(helper.RunCommand(Code));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="File"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult FileInclusion(string File)
        {
            return Ok(helper.ReadFile(File));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Filepath"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ArbitaryFileDelete(string Filepath)
        {
            return Ok(helper.DeleteFile(Filepath));
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="File"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UploadInsecureFile(IFormFile File)
        {
            return Ok(helper.uploadFile(File));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ServerSideRequestForgery(string URL)
        {
            return Ok(helper.GetRequest(URL));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult XmlExternalEntity()
        { 
            return Ok("Soon :))");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ReflectedCrossSiteScripting(string Name)
        {
            var data = "Welcome " + Name;
            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = "<html><body>" + data + "</body></html>"
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OpenURLRedirect(string URL)
        {
            return Redirect(URL);
        }



    }
}
