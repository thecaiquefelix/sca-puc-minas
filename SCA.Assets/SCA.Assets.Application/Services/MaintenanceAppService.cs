using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SCA.Assets.Application.Interfaces;
using SCA.Assets.Domain.DTO;
using SCA.Assets.Domain.Entities;
using SCA.Assets.Domain.Interfaces.Repository;

namespace SCA.Assets.Application.Services
{
    public class MaintenanceAppService : IMaintenanceAppService
    {
        private readonly IMaintenanceRepository _maintenanceRepository;

        public MaintenanceAppService(IMaintenanceRepository maintenance)
        {
            _maintenanceRepository = maintenance;
        }

        public async Task<Result<List<MaintenanceDTO>>> GetAllAsync()
        {
            try
            {
                var assets = await _maintenanceRepository.GetAllAsync();

                return new Result<List<MaintenanceDTO>>(assets);
            }
            catch (Exception ex)
            {
                return new Result<List<MaintenanceDTO>>(null, "Erro ao consultar ativo");
            }
        }

        public async Task<Result<Maintenance>> GetById(int id)
        {
            try
            {
                var maintenance = await _maintenanceRepository.GetById(id);

                return new Result<Maintenance>(maintenance);
            }
            catch (Exception ex)
            {
                return new Result<Maintenance>(null, "Erro ao consultar ativo pelo identificador");
            }
        }

        public async Task<Result> InsertAsync(Maintenance maintenance)
        {
            try
            {
                await _maintenanceRepository.InsertAsync(maintenance);

                return new Result();
            }
            catch (Exception ex)
            {
                return new Result("Erro ao inserir ativo");
            }
        }

        public async Task<Result> UpdateAsync(Maintenance maintenance)
        {
            try
            {
                await _maintenanceRepository.UpdateAsync(maintenance);

                return new Result();
            }
            catch (Exception ex)
            {
                return new Result("Erro ao atualizar ativo");
            }
        }

        public async Task<Result> DeleteAsync(int id)
        {
            try
            {
                await _maintenanceRepository.DeleteAsync(id);

                return new Result();
            }
            catch (Exception ex)
            {
                return new Result("Erro ao deletar ativo");
            }
        }   
    }
}
