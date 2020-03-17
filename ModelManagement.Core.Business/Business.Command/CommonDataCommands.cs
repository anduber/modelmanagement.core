using ModelManagement.Core.Business.Business.Command.Utils;
using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Model.CommandModel;
using System.Collections.Generic;
using ModelManagement.Core.Business.Business.Command.AppService;
using ModelManagement.Core.Business.Business.Command.CommandArgs;

namespace ModelManagement.Core.Business.Business.Command
{
    public class CommonDataCommands
    {

    }

    public class CreateGeoTypesCommand : CommandBase, ICommand
    {
        public List<GeoTypeArg> GeoTypeArgs { get; set; }

        public CommandResult Execute()
        {
            using (var transaction = new TransactionScope())
            {
                var commonDataService = new CommonDataService(transaction.Context);
                commonDataService.CreateGeoTypes(GeoTypeArgs);
                transaction.CompleteTransaction();
                return Utility.CommandSuccess();
            }
        }
    }

    public class CreateGeosCommand : CommandBase, ICommand
    {
        public List<GeoArg> GeoArgs { get; set; }
        public CommandResult Execute()
        {
            using (var transaction = new TransactionScope())
            {
                var commonDataService = new CommonDataService(transaction.Context);
                commonDataService.CreateGeos(GeoArgs);
                transaction.CompleteTransaction();
                return Utility.CommandSuccess();
            }

        }
    }

    public class CreateGeoAssocesCommand : CommandBase, ICommand
    {
        public List<GeoAssocArg> GeoAssocArgs { get; set; }
        public CommandResult Execute()
        {
            using (var transaction = new TransactionScope())
            {
                var commonDataService = new CommonDataService(transaction.Context);
                commonDataService.CreateGeoAssoces(GeoAssocArgs);
                transaction.CompleteTransaction();
                return Utility.CommandSuccess();
            }
        }
    }

    public class CreateOfferTypeCommand : CommandBase, ICommand
    {
        public string Sequence { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public int? ValidNoOfDays { get; set; }
        public decimal? FeeAmount { get; set; }
        public CommandResult Execute()
        {
            return new CommonDataService().CreateOfferType(Sequence, Description, LongDescription, ValidNoOfDays, FeeAmount, UserLoginId);
        }
    }

    public class UpdateOfferTypeCommand : CommandBase, ICommand
    {
        public string OfferTypeId { get; set; }
        public string Sequence { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public int? ValidNoOfDays { get; set; }
        public decimal? FeeAmount { get; set; }
        public CommandResult Execute()
        {
            return new CommonDataService().UpdateOfferType(OfferTypeId, Sequence, Description, LongDescription, ValidNoOfDays, FeeAmount, UserLoginId);
        }
    }

    public class DeactivateOfferTypeCommand : CommandBase, ICommand
    {
        public string OfferTypeId { get; set; }
        public CommandResult Execute()
        {
            return new CommonDataService().RemoveOfferType(OfferTypeId, false);
        }
    }

    public class RemoveOfferTypeCommand : CommandBase, ICommand
    {
        public string OfferTypeId { get; set; }
        public CommandResult Execute()
        {
            return new CommonDataService().RemoveOfferType(OfferTypeId, true);
        }
    }

    public class CreateOfferItemTypeCommand : CommandBase, ICommand
    {
        public string Sequence { get; set; }
        public string Description { get; set; }
        public string OfferTypeId { get; set; }
        public CommandResult Execute()
        {
            using (var transacion = new TransactionScope())
            {
                var result = new CommonDataService(transacion.Context).CreateOfferItemType(Sequence, Description, OfferTypeId, UserLoginId);
                transacion.CompleteTransaction();
                return result;
            }

        }
    }

    public class UpdateOfferItemTypeCommand : CommandBase, ICommand
    {
        public string OfferItemTypeId { get; set; }
        public string Sequence { get; set; }
        public string Description { get; set; }
        public CommandResult Execute()
        {
            return new CommonDataService().UpdateOfferItemType(OfferItemTypeId, Sequence, Description, UserLoginId);
        }
    }

    public class AddOfferItemTypeMapCommand : CommandBase, ICommand
    {
        public string OfferTypeId { get; set; }
        public string OfferItemTypeId { get; set; }
        public CommandResult Execute()
        {
            return new CommonDataService().AddOfferItemTypeMap(OfferTypeId, OfferItemTypeId, UserLoginId);
        }
    }

    public class RemoveOfferItemTypeMapCommand : CommandBase, ICommand
    {
        public string OfferTypeId { get; set; }
        public string OfferItemTypeId { get; set; }
        public CommandResult Execute()
        {
            return new CommonDataService().RemoveOfferItemTypeMap(OfferTypeId, OfferItemTypeId);
        }
    }

    public class CreateEnumerationTypeCommand : CommandBase, ICommand
    {
        public string EnumerationTypeId { get; set; }
        public string Description { get; set; }
        public CommandResult Execute()
        {
            return new CommonDataService().CreateEnumerationType(EnumerationTypeId, Description, UserLoginId);
        }
    }

    public class UpdateEnumerationTypeCommand : CommandBase, ICommand
    {
        public string EnumerationTypeId { get; set; }
        public string Description { get; set; }
        public CommandResult Execute()
        {
            return new CommonDataService().UpdateEnumerationType(EnumerationTypeId, Description);
        }
    }

    public class RemoveEnumerationTypeCommand : CommandBase, ICommand
    {
        public string EnumerationTypeId { get; set; }
        public CommandResult Execute()
        {
            return new CommonDataService().RemoveEnumerationType(EnumerationTypeId);
        }
    }

    public class CreateEnumerationCommand : CommandBase, ICommand
    {
        public string EnumerationId { get; set; }
        public string EnumerationTypeId { get; set; }
        public string Description { get; set; }
        public CommandResult Execute()
        {
            return new CommonDataService().CreateEnumeration(EnumerationId, EnumerationTypeId, Description, UserLoginId);
        }
    }

    public class RemoveEnumerationCommand : CommandBase, ICommand
    {
        public string EnumerationId { get; set; }
        public CommandResult Execute()
        {
            return new CommonDataService().RemoveEnumeration(EnumerationId);
        }
    }

    public class CreateGeoTypeCommand : CommandBase, ICommand
    {
        public string GeoTypeId { get; set; }
        public string Description { get; set; }
        public string GeoTypePurposeId { get; set; }

        public CommandResult Execute()
        {
            return new CommonDataService().CreateGeoType(GeoTypeId, Description, GeoTypePurposeId, UserLoginId);
        }
    }

    public class UpdateGeoTypeCommand:CommandBase,ICommand
    {
        public string GeoTypeId { get; set; }
        public string Description { get; set; }
        public string GeoTypePurposeId { get; set; }
        public CommandResult Execute()
        {
            return new CommonDataService().UpdateGeoType(GeoTypeId, Description, GeoTypePurposeId, UserLoginId);
        }
    }

    public class RemoveGeoTypeCommand : CommandBase, ICommand
    {
        public string GeoTypeId { get; set; }
        public CommandResult Execute()
        {
            return new CommonDataService().RemoveGeoType(GeoTypeId);
        }
    }
}
