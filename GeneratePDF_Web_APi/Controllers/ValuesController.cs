using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;
using System.Security.Policy;

namespace GeneratePDF_Web_APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpGet]
       public IActionResult gerneratePDF()
        {


            string htmlCode = System.IO.File.ReadAllText("HTML_page/Index.html");
            HtmlToPdf converter = new HtmlToPdf();

            converter.Options.PdfPageSize = PdfPageSize.A4;
            // converter.Options.PdfPageOrientation = ;
            converter.Options.WebPageWidth = 10;
            converter.Options.WebPageHeight = 10;

             
            PdfDocument doc = converter.ConvertHtmlString(htmlCode);
            byte[] pdf = doc.Save();
            doc.Close();

            FileResult fileResult = new FileContentResult(pdf, "application/pdf");
            fileResult.FileDownloadName = "Document.pdf";
            return fileResult;
           // return Ok();
        }

    }
}
