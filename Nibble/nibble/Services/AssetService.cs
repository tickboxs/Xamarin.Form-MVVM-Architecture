using System;
using System.Collections.Generic;
using nibble.Domains;
using nibble.Interfaces;
using nibble.Constants;
using System.Linq;

namespace nibble.Services
{
    public class AssetService:IAssetService
    {

        private IList<Asset> _assets = new List<Asset>
            {
            new Asset(0,AssetType.Cash,"Study",24680),
            new Asset(1,AssetType.Bitcoin,"Investment Stock",12456),
            new Asset(2,AssetType.Card,"JAN 2020",13579),
            new Asset(3,AssetType.Card,"Startup Business",32400),
            new Asset(4,AssetType.Property,"Family 2020",23400)
            };

        public AssetService()
        {
        }

        public void CreateAsset(Asset asset)
        {
            var maxId = _assets.Max((innerAsset) => innerAsset.Id);
            asset.Id = (maxId + 1);
            _assets.Add(asset);

        }

        public IList<Asset> GetAllAssets()
        {
            return _assets;
        }
    }
}
