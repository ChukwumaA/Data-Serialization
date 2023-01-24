using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Data_To_PDF;

public static class ConvertToPdf
{
    public static void CreatePdf(string documentContent, string fileName)
    {

        // Create a new PDF document
        var document = new Document();

        // Set the page size and margins
        document.SetPageSize(PageSize.A4);
        document.SetMargins(50, 50, 50, 50);
        
        // Create a new PdfWriter object
        var writer = PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));

        // Open the document for writing
        document.Open();

        // Create a new font and add it to the document
        var font = new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL);
        document.Add(new Paragraph(documentContent, font));

        // Close the document
        document.Close();
    }
}