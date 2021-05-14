using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SCA.Assets.Application.Interfaces;
using SCA.Assets.Domain.Entities;
using SCA.Assets.Domain.Interfaces.Repository;

namespace SCA.Assets.Application.Services
{
    public class AssetAppService : IAssetAppService
    {
        private readonly IAssetRepository _assetRepository;

        public AssetAppService(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public async Task<Result<List<Asset>>> GetAllAsync()
        {
            try
            {
                var assets = await _assetRepository.GetAllAsync();

                return new Result<List<Asset>>(assets);
            }
            catch (Exception ex)
            {
                return new Result<List<Asset>>(null, "Erro ao consultar ativo");
            }
        }

        public async Task<Result<Asset>> GetById(int id)
        {
            try
            {
                var asset = await _assetRepository.GetById(id);

                return new Result<Asset>(asset);
            }
            catch (Exception ex)
            {
                return new Result<Asset>(null, "Erro ao consultar ativo pelo identificador");
            }
        }

        public async Task<Result> InsertAsync(Asset asset)
        {
            try
            {
                await _assetRepository.InsertAsync(asset);

                return new Result();
            }
            catch (Exception ex)
            {
                return new Result<Asset>(null, "Erro ao inserir ativo");
            }
        }

        public async Task<Result> UpdateAsync(Asset asset)
        {
            try
            {
                await _assetRepository.UpdateAsync(asset);

                return new Result();
            }
            catch (Exception ex)
            {
                return new Result<Asset>(null, "Erro ao atualizar ativo");
            }
        }

        public async Task<Result> DeleteAsync(int id)
        {
            try
            {
                await _assetRepository.DeleteAsync(id);

                return new Result();
            }
            catch (Exception ex)
            {
                return new Result<Asset>(null, "Erro ao deletar ativo");
            }
        }   
    }
}
