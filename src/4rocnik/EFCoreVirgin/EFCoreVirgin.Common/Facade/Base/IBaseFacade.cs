using EFCoreVirgin.Common.Model;
using EFCoreVirgin.Common.Model.Base;

namespace EFCoreVirgin.Common.Facade.Base;

public interface IBaseFacade<TModel, TDetailModel, TEditModel>
 where TModel: IBaseModel
 where TDetailModel: IBaseDetailModel
 where TEditModel: IBaseEditModel
{
    TDetailModel GetById(int id);
    ListModel<TModel> GetAll();
    TDetailModel Create(TEditModel editModel);
    TDetailModel Update(int id, TEditModel editModel);
    TDetailModel Delete(int id);
}