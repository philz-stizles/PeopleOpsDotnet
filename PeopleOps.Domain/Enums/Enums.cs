using System.ComponentModel;

namespace PeopleOps.Domain.Enums
{
    public enum TransactType
    {
        BankAccount = 1,
    }

    public enum TransactRequestType
    {
        GetBalance = 1,
    }

    public enum QuoteStatus
    {
        Pending,
        Approved,
        Rejected
    }

    public enum TransactionStatus
    {
        Start = 1,
        Pending,
        Processing,
        Successful,
        Failed,
        Reversed
    }

    public enum PaymentStatus
    {
        NotPaid = 1,
        Processing,
        Paid,
    }

    public enum TitleType
    {
        Mr = 1,
        Mrs,
        Cheif,
        Dr
    }

    public enum GenderType
    {
        Male = 1,
        Female,
        Cheif,
        Dr
    }

    public enum MaritalStatusType
    {
        Single = 1,
        Married
    }

    // public enum InsuranceType
    // {
    //     Motor = 1,
    //     GeneralAccident,
    //     ConstructionAndEngineering,
    //     FireAndSpecialPerils,
    //     MarineAndAviation,
    //     SpecialRisk,
    //     OilAndGas,
    //     CompulsoryInsurance,
    //     TravelInsurance
    // }

    public enum InsuranceType
    {
        [Description("Third(3rd) Party Motor Insurance")]
        ThirdPartyMotorInsurance = 1,
        [Description("The Enhanced (3rd) Party")]
        TheEnhancedParty
    }


    public enum VehicleType
    {
        Fleet = 1
    }

    public enum VehicleClassType
    {
        [Description("Private Motor")]
        PrivateMotor = 11,
        [Description("Commercial Motor(OWN GOODS)")]
        CommercialMotorOwnGoods,
        [Description("Commercial Motor(STAFF BUS)")]
        CommercialMotorTrucksGeneral,
        [Description("Commercial VehicleTRUCKS/GENERAL CARTAGE")]
        CommercialVehicle,
        [Description("Motor Trade(PREMISES RISK)")]
        MotorTrade,
        [Description("Special Types (AMBULANCE)")]
        SpecialTypes,
        [Description("Motorcycle (POWER BIKE & OFFICIAL RIDE)")]
        MotorCycle,
        [Description("Private Cars Only")]
        PrivateCars = 20,
        [Description("Private Bus and Pick-up (Owned)")]
        PrivateBus,
        [Description("Private Goods Carrying Vehicle (for Insured own goods)")]
        PrivateGoods
    }

    public enum PolicyHolderType
    {
        Private = 30,
        Corporate,
        Comprehensive,
    }

    public enum DocumentType
    {
        UploadId = 1,
        VehicleLicense,
        ProofOfOwnership,
        FleetDetails,
        ApprovedForm,
        InvOfContent,
        DescOfBuilding,
        PoliceReport,
        IncidentFile1,
        IncidentFile2,
        IncidentFile3
    }

    public enum UserStatus
    {
        Admin = 1,
        AdminLead,
        Lead,
        Customer,
        AdminCustomer
    }

    public enum TemplateType
    {
        QuoteCreationNotification = 1,
        PolicyCreationNotification,
        ClaimCreationNotification
    }

    public enum EmailSubscriptionType
    {
        QuoteCreate = 1,
        PolicyCreate,
        Register,
        TransactionCreate,
        ClaimCreate
    }

    public enum ClaimStatusType
    {
        Pending = 1,
        Approved,
        Rejected,
    }

    public enum ActionType
    {
        Pending = 1,
        Approved,
        Rejected,
    }
}
