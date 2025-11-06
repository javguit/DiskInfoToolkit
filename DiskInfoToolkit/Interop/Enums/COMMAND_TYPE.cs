namespace DiskInfoToolkit.Interop.Enums
{
    internal enum COMMAND_TYPE : byte
    {
        CMD_TYPE_UNKNOWN = 0,
        CMD_TYPE_PHYSICAL_DRIVE,
        CMD_TYPE_SCSI_MINIPORT,
        CMD_TYPE_SILICON_IMAGE,
        CMD_TYPE_SAT,           // SAT = SCSI_ATA_TRANSLATION
        CMD_TYPE_SUNPLUS,
        CMD_TYPE_IO_DATA,
        CMD_TYPE_LOGITEC,
        CMD_TYPE_PROLIFIC,
        CMD_TYPE_JMICRON,
        CMD_TYPE_CYPRESS,
        CMD_TYPE_SAT_ASM1352R,  // AMS1352 2nd drive
        CMD_TYPE_SAT_REALTEK9220DP,
        CMD_TYPE_CSMI,              // CSMI = Common Storage Management Interface
        CMD_TYPE_CSMI_PHYSICAL_DRIVE, // CSMI = Common Storage Management Interface 
        CMD_TYPE_WMI,
        CMD_TYPE_NVME_SAMSUNG,
        CMD_TYPE_NVME_INTEL,
        CMD_TYPE_NVME_STORAGE_QUERY,
        CMD_TYPE_NVME_JMICRON,
        CMD_TYPE_NVME_ASMEDIA,
        CMD_TYPE_NVME_REALTEK,
        CMD_TYPE_NVME_REALTEK9220DP,
        CMD_TYPE_NVME_INTEL_RST,
        CMD_TYPE_NVME_INTEL_VROC,
        CMD_TYPE_MEGARAID,
        CMD_TYPE_AMD_RC2,// +AMD_RC2
        CMD_TYPE_JMS56X,
        CMD_TYPE_JMB39X,
        CMD_TYPE_JMS586_20,
        CMD_TYPE_JMS586_40,
        CMD_TYPE_DEBUG
    }
}
