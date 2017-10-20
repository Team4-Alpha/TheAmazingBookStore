
            Book book = this.context.Books.Find(id);

            title = book.Title;
            foreach (var item in book.Genres)
            {
                genres += (item.Name + "\n");
            }

            foreach (var item in book.Authors)
            {
                authors += item.FirstName + " " + item.LastName + "\n";
            }
            description = book.Description;
            rating = book.Rating;
            price = book.Price;

            foreach (var item in book.Sellers)
            {
                sellers += item.FirstName + " " + item.LastName + "\n";
            }


            var result = $@"Title: {title}
Genres: {genres}
Author: {authors}
Description: {description}
Rating: {rating}
Price: {price}
Sellers: {sellers}";
{
    public class FindBookCommand : ICommand
            double rating;
            decimal price;
            string sellers = "";
            Book book = this.context.Books.Find(id);

            title = book.Title;
            foreach (var item in book.Genres)
            {
                genres += (item.Name + "\n");
            }

            foreach (var item in book.Authors)
            {
                authors += item.FirstName + " " + item.LastName + "\n";
            }
            description = book.Description;
            rating = book.Rating;
            price = book.Price;

            foreach (var item in book.Sellers)
            {
                sellers += item.FirstName + " " + item.LastName + "\n";
            }


            var result = $@"Title: {title}
Genres: {genres}
Author: {authors}
Description: {description}
Rating: {rating}
Price: {price}
Sellers: {sellers}";