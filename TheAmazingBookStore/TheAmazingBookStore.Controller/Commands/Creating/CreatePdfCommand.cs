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

namespace TheAmazingBookStore.Controller.Commands
{
    public class CreatePdfCommand :  IPdfReporter, ICommand
    {
        private readonly IBookStoreContext context;
        public CreatePdfCommand(BookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;

        }
        public string Execute(IList<string> parameters)
        {
            var books = this.context.Books;
            var findBook = new FindBookCommand(this.context);
            StringBuilder sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine(findBook.Execute(new List<string> { $"{book.Id}" }));
            }
            FileStream fs = new FileStream("Books.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            doc.Add(new Paragraph(fs.ToString()));
            doc.Close();

            return "PDF document is ready.";
            
            
        }
    }
}
