namespace SWAPI.MAPPER
{
  /// <summary>
  /// Interface IMapper
  /// </summary>
  /// <typeparam name="TSource">The type of the source.</typeparam>
  /// <typeparam name="TDestination">The type of the destination.</typeparam>
  public interface IMapper<TSource, TDestination>
  {
    TDestination Map(TSource source);
  }
}