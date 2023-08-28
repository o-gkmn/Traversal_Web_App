using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Web_App.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdf_reports/"+"dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();
            Paragraph paragraph = new("Traversal Rezervasyon Pdf Raporu");
            document.Add(paragraph);
            document.Close();
            return File("/pdf_reports/dosya1.pdf", "application/pdf", "dosya1.pdf");

        }

        public IActionResult StaticCustomerResult()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdf_reports/" + "dosya2.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();
            PdfPTable table = new(3);

            table.AddCell("Misafir Adı");
            table.AddCell("Misafir Soyadı");
            table.AddCell("Misafir TC");

            table.AddCell("Özgür");
            table.AddCell("Gökmen");
            table.AddCell("123456789");

            table.AddCell("Safiye");
            table.AddCell("Gökmen");
            table.AddCell("123456789");

            table.AddCell("Selami");
            table.AddCell("Gökmen");
            table.AddCell("123456789");

            table.AddCell("Özge");
            table.AddCell("Gökmen");
            table.AddCell("123456789");

            document.Add(table);

            document.Close();
            return File("/pdf_reports/dosya2.pdf", "application/pdf", "dosya2.pdf");

        }
    }
}
