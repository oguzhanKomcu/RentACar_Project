namespace Core.Persistence.Paging;
//IPaginate sayfalama konusunda bize yardımcı olacak alanalrımızı bulunduruyor. 
public interface IPaginate<T>
{
    int From { get; } //Nereden
    int Index { get; } //Kaçıncı index kaçıncı sayfa
    int Size { get; } 
    int Count { get; }
    int Pages { get; }
    IList<T> Items { get; } //verilerin oldugu yer 
    bool HasPrevious { get; }
    bool HasNext { get; }
}