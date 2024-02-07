namespace Rhythm.Drop.Web.Infrastructure.Factories.MetaData;

using Rhythm.Drop.Web.Infrastructure.MetaData;

/// <summary>
/// A contract for creating a factory that creates <see cref="MetaData"/>.
/// </summary>
public interface IMetaDataFactory<in TInput, out TMetaData> where TMetaData : MetaData
{
    /// <summary>
    /// Creates a <typeparamref name="TMetaData"/> for a given input.
    /// </summary>
    /// <param name="input">The input required to create a <typeparamref name="TMetaData"/> object.</param>
    /// <returns>A <typeparamref name="TMetaData"/>.</returns>
    TMetaData Create(TInput input);
}