using LinqJoin;

class Program
{
    static void Main(string[] args)
    {
        //
        //Listelerimizi oluşturup veri girişini yaptık
        List<Authors> author = new List<Authors>();
        author.Add(new Authors { AuthorId = 1, Name = "Orhan Pamuk" });
        author.Add(new Authors { AuthorId = 2, Name = "Elif Şafak" });
        author.Add(new Authors { AuthorId = 3, Name = "Ahmet Ümit" });
        //listelerimizin veri girişini yaptık
        List<Books> book = new List<Books>();
        book.Add(new Books { BookId = 1, Title = "Kar", AuthorId = 1 });
        book.Add(new Books { BookId = 2, Title = "İstanbul", AuthorId = 1 });
        book.Add(new Books { BookId = 3, Title = "10 Minutes 38 Seconds in This Strange World", AuthorId = 2 });
        book.Add(new Books { BookId = 4, Title = "Beyoğlu Rapsodisi", AuthorId = 3 });

        /*
            AuthorBook adın da var tipinde bir değişken tanımladık
            from authors in author diyerek author içerisinde bir döngü oluşturduk ve her bir ögeyi authors a taşıdık
            join işlemi yaparak birleştireceğimiz tablonun adını yazdık ve aynı şekilde döngüyü oluşturup books un içine taşıdık
            on anahtar kelimesini kullanarak hangi alanlar üzerinden eşitliyeceğimizi belirttik iki taraftaki authorId alanlarını eşit mi diye equals ile kontrolünü sağladık
            daha sonra anonim bir nesne oluşturduk ve bu eşleşmenin sonucunda hangi verilerimizi seçeceğimizi belirttik.
         */
        var AuthorBook = from authors in author
                         join books in book on authors.AuthorId equals books.AuthorId
                         select new
                         {
                             BookName = books.Title,
                             AuthorName = authors.Name
                         };
        //foreach ile oluşturduğumuz filtreli değişkenimizin içene girip verilerimizi dönerek ekrana basıyoruz
        foreach(var item in AuthorBook)
        {
            Console.WriteLine($"Kitabın Adı : {item.BookName} - Kitabın Yazarı : {item.AuthorName}");
        }
    }
}