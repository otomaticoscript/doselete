using Doselete.Domain.Repository.Data;
using Doselete.Domain.Entity;
namespace Doselete.Application.UserCase
{
    public interface IMasterManager
    {
        public Task<List<Master>> GetMasters();
        public Task<List<Master>> GetMastersbyLikeName(string name);
        public Task<int?> SetMaster(Master master);
        public Task RemoveMaster(int idMaster);
        //Option Sector
        public Task<List<MasterOption>> GetOptions(int idMaster);
        public Task SetOptions(MasterOption[] options);
        public Task RemoveOptions(int idOption);
    }

    public class MasterManager : IMasterManager
    {
        private readonly IMasterData _masterData;
        public MasterManager(IMasterData masterData)
        {
            _masterData = masterData;
        }

        #region Master
        public async Task<List<Master>> GetMasters()
        {
            return await _masterData.GetMastersAsync();
        }
        public async Task<List<Master>> GetMastersbyLikeName(string name)
        {
            return await _masterData.GetMastersByNameAsync(name);
        }
        public async Task<int?> SetMaster(Master master)
        {
            if (master.Id == null)
            {
                await _masterData.InsertMasterAsync(master);
            }
            else
            {
                await _masterData.UpdateMasterAsync(master);
            }
            return master.Id;
        }

        public async Task RemoveMaster(int idMaster)
        {
            await _masterData.DeleteOptionsByIdMasterAsync(idMaster);
            await _masterData.DeleteMasterAsync(idMaster);
        }
        #endregion

        #region Option
        public async Task<List<MasterOption>> GetOptions(int idMaster)
        {
            return await _masterData.GetMasterOptionAsync(idMaster);
        }

        public async Task SetOptions(MasterOption[] options)
        {
            MasterOption[] insert = options.Where(w => w.Id == null).ToArray();
            MasterOption[] update = options.Where(w => w.Id != null).ToArray();
            if (insert.Count() > 0)
            {
                await _masterData.InsertOptionAsync(insert);
            }
            if (update.Count() > 0)
            {
                await _masterData.UpdateOptionAsync(update);
            }
        }

        public async Task RemoveOptions(int idOption)
        {
            await _masterData.DeleteOptionAsync(idOption);
        }
        #endregion
    }
}