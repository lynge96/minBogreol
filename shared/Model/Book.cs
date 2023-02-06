using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace shared.Model;

public class Book
{
    // MongoDB sørger for at generere og omdanne string Id til et objectId i databasen
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string? Titel { get; set; }

    public string? Forfatter { get; set; }

    public string? Forlag { get; set; }

    public int UdgivelsesÅr { get; set; }

    public int Sider { get; set; }

    public string? Genre { get; set; }

    public bool Læst { get; set; }

    public string? Sprog { get; set; }

    // Tom constructor er nødvendig for at sende data igennem API
    public Book() {

    }

    public Book(string id, string titel, string forfatter, string forlag, int år, int sider, string genre, bool læst, string sprog)
    {
        this.Id = id;
        this.Titel = titel;
        this.Forfatter = forfatter;
        this.Forlag = forlag;
        this.UdgivelsesÅr = år;
        this.Sider = sider;
        this.Genre = genre;
        this.Læst = læst;
        this.Sprog = sprog;
    }

    public override string ToString()
    {
        string toString = $"Titel: {Titel}\nForfatter: {Forfatter}\nForlag: {Forlag}\nÅr: {UdgivelsesÅr}\nGenre: {Genre}\n";

        return toString;
    }
}