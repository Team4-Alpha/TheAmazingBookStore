using Bytes2you.Validation;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Controller.Commands.FindCommand;
using TheAmazingBookStore.Data;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Controller.Commands
{
    public class PdfReporter :FindBookCommand,  IPdfReporter, Contracts.ICommand
    {
        private readonly IBookStoreContext context;
        public PdfReporter(BookStoreContext context)
            :base(context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;

        }
        public override string Execute(IList<string> parameters)
        {
           
            var res = base.Execute(parameters);
            FileStream fs = new FileStream("Book.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            doc.Add(new Paragraph(res));
            doc.Close();

            return "PDF document is ready.";
            
            
        }
    }
}
