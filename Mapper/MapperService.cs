namespace SWAPI.MAPPER
{
  public class MapperService
  {
    private readonly ILogger<MapperService> _logger;

    private readonly Dictionary<(Type Source, Type Destination), object> _mappers = new();
    /// <summary>
    /// Registers a mapper for the specified source and destination types.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TDestination"></typeparam>
    /// <param name="mapper"></param>
    public void RegisterMapper<TSource, TDestination>(IMapper<TSource, TDestination> mapper)
    {
      var key = (typeof(TSource), typeof(TDestination));
      _mappers[key] = mapper;
    }
    /// <summary>
    /// Maps the source object to the destination type.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TDestination"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public TDestination Map<TSource, TDestination>(TSource source)
    {
      var key = (typeof(TSource), typeof(TDestination));

      if (_mappers.TryGetValue(key, out var mapper))
      {
        return ((IMapper<TSource, TDestination>)mapper).Map(source);
      }

      throw new InvalidOperationException($"No mapper registered for {typeof(TSource)} to {typeof(TDestination)}");
    }
  }
}