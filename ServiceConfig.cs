using System;
using System.Collections.Generic;
using System.Management;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace ToolBOX_by_Naetech
{
    public partial class ServiceConfig
    {
        public string Name { get; set; }
        public ServiceStartupType DesiredStartupType { get; set; }

        public async Task ApplyServiceOptimizationsAsync()
        {
            List<ServiceConfig> configs = new List<ServiceConfig>
        {
            new ServiceConfig { Name = "AJRouter", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "ALG", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "AppIDSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "AppMgmt", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "AppReadiness", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "AppVClient", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "AppXSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "Appinfo", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "AssignedAccessManagerSvc", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "AudioEndpointBuilder", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "AudioSrv", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "Audiosrv", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "AxInstSV", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "BDESVC", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "BFE", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "BITS", DesiredStartupType = ServiceStartupType.AutomaticDelayedStart },
            new ServiceConfig { Name = "BTAGService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "BcastDVRUserService_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "BluetoothUserService_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "BrokerInfrastructure", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "Browser", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "BthAvctpSvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "BthHFSrv", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "CDPSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "CDPUserSvc_*", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "COMSysApp", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "CaptureService_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "CertPropSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "ClipSVC", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "ConsentUxUserSvc_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "CoreMessagingRegistrar", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "CredentialEnrollmentManagerUserSvc_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "CryptSvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "CscService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "DPS", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "DcomLaunch", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "DcpSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "DevQueryBroker", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "DeviceAssociationBrokerSvc_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "DeviceAssociationService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "DeviceInstall", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "DevicePickerUserSvc_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "DevicesFlowUserSvc_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "Dhcp", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "DiagTrack", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "DialogBlockingService", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "DispBrokerDesktopSvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "DisplayEnhancementService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "DmEnrollmentSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "Dnscache", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "DoSvc", DesiredStartupType = ServiceStartupType.AutomaticDelayedStart },
            new ServiceConfig { Name = "DsSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "DsmSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "DusmSvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "EFS", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "EapHost", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "EntAppSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "EventLog", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "EventSystem", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "FDResPub", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "Fax", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "FontCache", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "FrameServer", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "FrameServerMonitor", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "GraphicsPerfSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "HomeGroupListener", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "HomeGroupProvider", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "HvHost", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "IEEtwCollectorService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "IKEEXT", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "InstallService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "InventorySvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "IpxlatCfgSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "KeyIso", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "KtmRm", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "LSM", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "LanmanServer", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "LanmanWorkstation", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "LicenseManager", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "LxpSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "MSDTC", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "MSiSCSI", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "MapsBroker", DesiredStartupType = ServiceStartupType.AutomaticDelayedStart },
            new ServiceConfig { Name = "McpManagementService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "MessagingService_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "MicrosoftEdgeElevationService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "MixedRealityOpenXRSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "MpsSvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "MsKeyboardFilter", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "NPSMSvc_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "NaturalAuthentication", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "NcaSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "NcbService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "NcdAutoSetup", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "NetSetupSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "NetTcpPortSharing", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "Netlogon", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "Netman", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "NgcCtnrSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "NgcSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "NlaSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "OneSyncSvc_*", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "P9RdrService_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "PNRPAutoReg", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "PNRPsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "PcaSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "PeerDistSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "PenService_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "PerfHost", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "PhoneSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "PimIndexMaintenanceSvc_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "PlugPlay", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "PolicyAgent", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "Power", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "PrintNotify", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "PrintWorkflowUserSvc_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "ProfSvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "PushToInstall", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "QWAVE", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "RasAuto", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "RasMan", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "RemoteAccess", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "RemoteRegistry", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "RetailDemo", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "RmSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "RpcEptMapper", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "RpcLocator", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "RpcSs", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "SCPolicySvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SCardSvr", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SDRSVC", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SEMgrSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SENS", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "SNMPTRAP", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SNMPTrap", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SSDPSRV", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SamSs", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "ScDeviceEnum", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "Schedule", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "SecurityHealthService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "Sense", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SensorDataService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SensorService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SensrSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SessionEnv", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SgrmBroker", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "SharedAccess", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SharedRealitySvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "ShellHWDetection", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "SmsRouter", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "Spooler", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "SstpSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "StateRepository", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "StiSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "StorSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "SysMain", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "SystemEventsBroker", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "TabletInputService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "TapiSrv", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "TermService", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "TextInputManagementService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "Themes", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "TieringEngineService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "TimeBroker", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "TimeBrokerSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "TokenBroker", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "TrkWks", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "TroubleshootingSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "TrustedInstaller", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "UI0Detect", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "UdkUserSvc_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "UevAgentService", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "UmRdpService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "UnistoreSvc_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "UserDataSvc_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "UserManager", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "UsoSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "VGAuthService", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "VMTools", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "VSS", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "VacSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "VaultSvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "W32Time", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WEPHOSTSVC", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WFDSConMgrSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WMPNetworkSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WManSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WPDBusEnum", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WSService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WSearch", DesiredStartupType = ServiceStartupType.AutomaticDelayedStart },
            new ServiceConfig { Name = "WaaSMedicSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WalletService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WarpJITSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WbioSrvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "Wcmsvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "WcsPlugInService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WdNisSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WdiServiceHost", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WdiSystemHost", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WebClient", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "Wecsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WerSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WiaRpc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WinDefend", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "WinHttpAutoProxySvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WinRM", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "Winmgmt", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "WlanSvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "WpcMonSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WpnService", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "WpnUserService_*", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "XblAuthManager", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "XblGameSave", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "XboxGipSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "XboxNetApiSvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "autotimesvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "bthserv", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "camsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "cbdhsvc_*", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "cloudidsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "dcsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "defragsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "diagnosticshub.standardcollector.service", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "diagsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "dmwappushservice", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "dot3svc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "edgeupdate", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "edgeupdatem", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "embeddedmode", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "fdPHost", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "fhsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "gpsvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "hidserv", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "icssvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "iphlpsvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "lfsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "lltdsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "lmhosts", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "mpssvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "msiserver", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "netprofm", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "nsi", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "p2pimsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "p2psvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "perceptionsimulation", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "pla", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "seclogon", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "shpamsvc", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "smphost", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "spectrum", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "sppsvc", DesiredStartupType = ServiceStartupType.AutomaticDelayedStart },
            new ServiceConfig { Name = "ssh-agent", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "svsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "swprv", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "tiledatamodelsvc", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "tzautoupdate", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "uhssvc", DesiredStartupType = ServiceStartupType.Disabled },
            new ServiceConfig { Name = "upnphost", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "vds", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "vm3dservice", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "vmicguestinterface", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "vmicheartbeat", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "vmickvpexchange", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "vmicrdv", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "vmicshutdown", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "vmictimesync", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "vmicvmsession", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "vmicvss", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "vmvss", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "wbengine", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "wcncsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "webthreatdefsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "webthreatdefusersvc_*", DesiredStartupType = ServiceStartupType.Automatic },
            new ServiceConfig { Name = "wercplsupport", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "wisvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "wlidsvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "wlpasvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "wmiApSrv", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "workfolderssvc", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "wscsvc", DesiredStartupType = ServiceStartupType.AutomaticDelayedStart },
            new ServiceConfig { Name = "wuauserv", DesiredStartupType = ServiceStartupType.Manual },
            new ServiceConfig { Name = "wudfsvc", DesiredStartupType = ServiceStartupType.Manual }
        };

            foreach (var config in configs)
            {
                try
                {
                    await Task.Run(() =>
                    {
                        SetServiceStartupType(config.Name, config.DesiredStartupType);

                        using (ServiceController service = new ServiceController(config.Name))
                        {
                            if ((config.DesiredStartupType == ServiceStartupType.Disabled || config.DesiredStartupType == ServiceStartupType.Manual) &&
                                (service.Status == ServiceControllerStatus.Running || service.Status == ServiceControllerStatus.StartPending))
                            {
                                service.Stop();
                                service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                            }
                            else if (config.DesiredStartupType == ServiceStartupType.Automatic && service.Status != ServiceControllerStatus.Running)
                            {
                                service.Start();
                                service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                            }
                        }
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing service '{config.Name}': {ex.Message}");
                }
            }
        }

        private void SetServiceStartupType(string serviceName, ServiceStartupType startupType)
        {
            string wmiStartupType;
            switch (startupType)
            {
                case ServiceStartupType.Automatic:
                    wmiStartupType = "Automatic";
                    break;
                case ServiceStartupType.AutomaticDelayedStart:
                    wmiStartupType = "Automatic";
                    break;
                case ServiceStartupType.Manual:
                    wmiStartupType = "Manual";
                    break;
                case ServiceStartupType.Disabled:
                    wmiStartupType = "Disabled";
                    break;
                default:
                    throw new ArgumentException("Invalid ServiceStartupType.");
            }

            using (ManagementObject service = new ManagementObject($"Win32_Service.Name='{serviceName}'"))
            {
                ManagementBaseObject inParams = service.GetMethodParameters("ChangeStartMode");
                inParams["StartMode"] = wmiStartupType;
                service.InvokeMethod("ChangeStartMode", inParams, null);
            }
        }

        public enum ServiceStartupType
        {
            Automatic,
            AutomaticDelayedStart,
            Manual,
            Disabled
        }
    }
}
