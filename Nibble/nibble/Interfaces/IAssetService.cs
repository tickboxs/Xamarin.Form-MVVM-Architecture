using System;
using System.Collections.Generic;
using nibble.Domains;
namespace nibble.Interfaces
{
    public interface IAssetService
    {
        IList<Asset> GetAllAssets();
        void CreateAsset(Asset asset);
    }
}
