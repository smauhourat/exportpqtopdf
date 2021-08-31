using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Geom;

namespace exportpqtopdf
{
    class Program
    {
        //public string[] filesProducts = new string[] { 
        //    "../../../resources/productDocument-77fc3588-25f1-438c-87f7-87578e7470d9.pdf", 
        //    "../../../resources/productDocument-c8ac3e2a-453b-44d6-a190-92d98ef15073.pdf" 
        //};
        //public const string fileTemplate = "../../../resources/pq_template.pdf";
        //public const string fileExport = "../../../results/pq.pdf";

        public static string[] filesProducts = new string[] {
            "productDocument-77fc3588-25f1-438c-87f7-87578e7470d9.pdf",
            "productDocument-c8ac3e2a-453b-44d6-a190-92d98ef15073.pdf"
        };
        public const string fileTemplate = "pq_template.pdf";
        public const string fileExport = "pq.pdf";

        static void Main(string[] args)
        {
            new PdfManagerService().ProductQuoteToPdf(fileTemplate, fileExport, filesProducts);
            Environment.Exit(0);
        }
    }

    internal class PdfManagerService
    {
        internal void ProductQuoteToPdf(string fileTemplate, string fileExport, string[] filesProducts)
        {
            string fileTemplatePath = "resources/" + fileTemplate;
            string fileExportPath = "results/" + fileExport;

            StampPdf(fileTemplatePath, fileExportPath);
        }

        internal void StampPdf(string fileTemplatePath, string fileExportPath)
        {
            //Initialize PDF document
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(fileTemplatePath), new PdfWriter(fileExportPath));
            PdfPage firstPage = pdfDoc.GetFirstPage();
            PdfCanvas canvas = new PdfCanvas(firstPage);

            PdfFont baseFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            string text = "";
            const float FONT_SIZE = 10;
            const float LEFT_MARGIN = 245;
            const float TOP_MARGIN = 630;
            const float PADDING_TOP = 18; //612


            string fechaString = DateTime.Now.ToLongDateString();
            text = "Buenos Aires, " + fechaString.Substring(fechaString.IndexOf(",") + 2, fechaString.Length - (fechaString.IndexOf(",") + 2));
            canvas.BeginText().SetFontAndSize(baseFont, FONT_SIZE).MoveText(350, 720).ShowText(text).EndText();

            //text = productQuote.CustomerCompany;
            text = "Customer Company";
            canvas.BeginText().SetFontAndSize(baseFont, FONT_SIZE).MoveText(105, 685).ShowText(text).EndText();

            //text = productQuote?.CustomerContactName.ToString();
            text = "Nombre del Contacto";
            canvas.BeginText().SetFontAndSize(baseFont, FONT_SIZE).MoveText(105, 672).ShowText(text).EndText();

            //text = productQuote.ProductQuoteCode;
            text = "COT - 20181108-185";
            canvas.BeginText().SetFontAndSize(baseFont, FONT_SIZE).MoveText(220, 650).ShowText(text).EndText();

            //text = productQuote.ProductSingleName;
            text = "Agua Amoniacal 20%";
            canvas.BeginText().SetFontAndSize(baseFont, FONT_SIZE).MoveText(LEFT_MARGIN, TOP_MARGIN).ShowText(text).EndText();

            //text = productQuote.ProductBrandName.ToString();
            text = "Inquimex";
            canvas.BeginText().SetFontAndSize(baseFont, FONT_SIZE).MoveText(LEFT_MARGIN, TOP_MARGIN - (PADDING_TOP)).ShowText(text).EndText();

            //text = productQuote.ProductPackagingName.ToString();
            text = "Tambores 200 L";
            canvas.BeginText().SetFontAndSize(baseFont, FONT_SIZE).MoveText(LEFT_MARGIN, TOP_MARGIN - (PADDING_TOP * 2)).ShowText(text).EndText();

            //productQuote.ProductValidityOfPrice
            text = "01/01/2019";
            canvas.BeginText().SetFontAndSize(baseFont, FONT_SIZE).MoveText(LEFT_MARGIN, TOP_MARGIN - (PADDING_TOP * 3)).ShowText(text).EndText();

            //text = productQuote.SaleModalityName
            text = "Distribución Local";
            canvas.BeginText().SetFontAndSize(baseFont, FONT_SIZE).MoveText(LEFT_MARGIN, TOP_MARGIN - (PADDING_TOP * 4)).ShowText(text).EndText();

            // productQuote.DeliveryAddress or GeographicAreaName
            text = "Planta Local AGM";
            canvas.BeginText().SetFontAndSize(baseFont, FONT_SIZE).MoveText(LEFT_MARGIN, TOP_MARGIN - (PADDING_TOP * 5)).ShowText(text).EndText();

            //text = productQuote.PaymentDeadlineName;
            text = "45 Días FF";
            canvas.BeginText().SetFontAndSize(baseFont, FONT_SIZE).MoveText(LEFT_MARGIN, TOP_MARGIN - (PADDING_TOP * 6)).ShowText(text).EndText();

            //text = productQuote.QuantityOpenPurchaseOrder.ToString("#,##0");
            text = "7.200";
            canvas.BeginText().SetFontAndSize(baseFont, FONT_SIZE).MoveText(LEFT_MARGIN, TOP_MARGIN - (PADDING_TOP * 7)).ShowText(text).EndText();

            //text = productQuote.DeliveryAmount y algo mas
            text = "1 Entrega";
            canvas.BeginText().SetFontAndSize(baseFont, FONT_SIZE).MoveText(LEFT_MARGIN, TOP_MARGIN - (PADDING_TOP * 8)).ShowText(text).EndText();

            //text = productQuote.MinimumQuantityDelivery.ToString("#,##0");
            text = "7.200";
            canvas.BeginText().SetFontAndSize(baseFont, FONT_SIZE).MoveText(LEFT_MARGIN, TOP_MARGIN - (PADDING_TOP * 9)).ShowText(text).EndText();

            //text = productQuote.MaximumMonthsStock.ToString() + " Meses";
            text = "0 Meses";
            canvas.BeginText().SetFontAndSize(baseFont, FONT_SIZE).MoveText(LEFT_MARGIN, TOP_MARGIN - (PADDING_TOP * 10)).ShowText(text).EndText();

            //text = productQuote.ExchangeTypeName;
            text = "Dólares";
            canvas.BeginText().SetFontAndSize(baseFont, FONT_SIZE).MoveText(LEFT_MARGIN, TOP_MARGIN - (PADDING_TOP * 11)).ShowText(text).EndText();

            //text = Helper.RoundDecimal(productQuote.Price, 3).ToString("#,###0.000");
            text = "0,600";
            canvas.BeginText().SetFontAndSize(baseFont, FONT_SIZE).MoveText(LEFT_MARGIN, TOP_MARGIN - (PADDING_TOP * 12)).ShowText(text).EndText();

            //text = Helper.RoundDecimal(productQuote.Price * productQuote.MinimumQuantityDelivery, 2).ToString("#,##0.00");
            text = "4.321,34";
            canvas.BeginText().SetFontAndSize(baseFont, FONT_SIZE).MoveText(LEFT_MARGIN, TOP_MARGIN - (PADDING_TOP * 13)).ShowText(text).EndText();

            //text = Helper.RoundDecimal(productQuote.Price * productQuote.QuantityOpenPurchaseOrder, 2).ToString("#,##0.00");
            text = "4.321,34";
            canvas.BeginText().SetFontAndSize(baseFont, FONT_SIZE).MoveText(LEFT_MARGIN, TOP_MARGIN - (PADDING_TOP * 14)).ShowText(text).EndText();

            //text = productQuote.UserObservations + Environment.NewLine + productQuote.Observations;
            text = "Lorem Ipsum es simplemente el texto de relleno\n de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años, sino que tambien ingresó como texto de relleno en documentos electrónicos, quedando esencialmente igual al original. Fue popularizado en los 60s con la creación de las hojas 'Letraset', las cuales contenian pasajes de Lorem Ipsum, y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum.";
            Text observations = new Text(text).SetFont(baseFont);
            Paragraph paragrahpObservations = new Paragraph().Add(observations)
                .SetFontSize(FONT_SIZE - 2)
                .SetWidth(270)
                .SetHeight(125)
                .SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            PdfCanvas pdfCanvasObservations = new PdfCanvas(firstPage);
            pdfCanvasObservations.Stroke();
            Canvas canvasObservations = new Canvas(pdfCanvasObservations, new Rectangle(LEFT_MARGIN, TOP_MARGIN - (PADDING_TOP * 21), 270, 125));
            canvasObservations.Add(paragrahpObservations);


            //text = productQuote.UserFullName;
            text = "Jose Perez\nQuimkong.com";
            Text signature = new Text(text).SetFont(baseFont);
            Paragraph paragrahpSignature = new Paragraph().Add(signature)
                .SetFontSize(FONT_SIZE)
                .SetWidth(130)
                .SetHeight(50)
                .SetBorder(iText.Layout.Borders.Border.NO_BORDER)
                .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

            PdfCanvas pdfCanvasSignature = new PdfCanvas(firstPage);
            pdfCanvasSignature.Stroke();
            Canvas canvasSignature = new Canvas(pdfCanvasSignature, new Rectangle(400, 100, 130, 50));
            canvasSignature.Add(paragrahpSignature);


            pdfDoc.Close();
        }
    }
}
