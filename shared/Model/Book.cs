public class Book
{
    public int Id { get; set; }
    public string Titel { get; set; }
    public string Forfatter { get; set; }
    public string Forlag { get; set; }
    public int År { get; set; }
    public int Sider { get; set; }
    public string Genre { get; set; }
    public bool Læst { get; set; }


    Book(int id, string titel, string forfatter, string forlag, int år, int sider, string genre, bool læst)
    {
        this.Id = id;
        this.Titel = titel;
        this.Forfatter = forfatter;
        this.Forlag = forlag;
        this.År = år;
        this.Sider = sider;
        this.Genre = genre;
        this.Læst = læst;
    }

    public override string ToString()
    {
        string toString = $"Titel: {Titel}\nForfatter: {Forfatter}\nForlag: {Forlag}\nÅr: {År}\nGenre: {Genre}\n";

        return toString;
    }
}