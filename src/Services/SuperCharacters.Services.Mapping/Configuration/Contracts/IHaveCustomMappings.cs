namespace SuperCharacters.Services.Mapping.Contracts
{
    using AutoMapper;

    /// <summary>
    /// Every viewmodel which implements IHaveCustomMappings interface
    /// can configure non-orthodox mappings wihtin automapper.
    /// </summary>
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
