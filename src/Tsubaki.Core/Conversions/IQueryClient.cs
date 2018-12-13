
namespace Tsubaki.Core.Conversions
{
    public interface IQueryClient
    {
        IQueryConversion Query(string text);
    }
}
