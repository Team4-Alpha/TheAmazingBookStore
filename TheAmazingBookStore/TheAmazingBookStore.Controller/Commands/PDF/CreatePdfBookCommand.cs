using Bytes2you.Validation;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Controller.Commands.FindCommand;
using TheAmazingBookStore.Data;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Controller.Commands.PDF
{
    public class CreatePdfBookCommand :  IPdfReporter, ICommand
    {
        private readonly IBookStoreContext context;
        public CreatePdfBookCommand(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;

        }
        public string Execute(IList<string> parameters)
        {
            int id = int.Parse(parameters[0]);
            var findBook = new FindBookCommand(this.context);

            Book book = this.context.Books.Find(id);

            string result = findBook.Execute(new List<string> { $"{id}" });
            FileStream fs = new FileStream($"{book.Title}.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            doc.Add(new Paragraph(result));
            doc.Close();

            return $"The PDF document for {book.Title} is ready.";
            
            
        }
    }
}
