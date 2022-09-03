namespace Core.Persistence.Paging;

public class BasePageableModel
{
    public int Index { get; set; } //kaçıncı sayfada olduğumuz.
    public int Size { get; set; }  //Bir sayfada kaç tane verimiz var.
    public int Count { get; set; } //Toplamda kaç tane  verimiz var.
    public int Pages { get; set; } //Toplamda kaç tane sayfamız var.
    public bool HasPrevious { get; set; } //Önceki sayfa var mı ? 
    public bool HasNext { get; set; } //Sonraki sayfa var mı ? 
}