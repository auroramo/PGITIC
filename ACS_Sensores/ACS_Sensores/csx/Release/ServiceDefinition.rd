﻿<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="ACS_Sensores" generation="1" functional="0" release="0" Id="ba027482-7d6e-427c-ae9d-10bed234b829" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="ACS_SensoresGroup" generation="1" functional="0" release="0">
      <settings>
        <aCS name="WorkerRole1:APPINSIGHTS_INSTRUMENTATIONKEY" defaultValue="">
          <maps>
            <mapMoniker name="/ACS_Sensores/ACS_SensoresGroup/MapWorkerRole1:APPINSIGHTS_INSTRUMENTATIONKEY" />
          </maps>
        </aCS>
        <aCS name="WorkerRole1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/ACS_Sensores/ACS_SensoresGroup/MapWorkerRole1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="WorkerRole1Instances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/ACS_Sensores/ACS_SensoresGroup/MapWorkerRole1Instances" />
          </maps>
        </aCS>
      </settings>
      <maps>
        <map name="MapWorkerRole1:APPINSIGHTS_INSTRUMENTATIONKEY" kind="Identity">
          <setting>
            <aCSMoniker name="/ACS_Sensores/ACS_SensoresGroup/WorkerRole1/APPINSIGHTS_INSTRUMENTATIONKEY" />
          </setting>
        </map>
        <map name="MapWorkerRole1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/ACS_Sensores/ACS_SensoresGroup/WorkerRole1/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapWorkerRole1Instances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/ACS_Sensores/ACS_SensoresGroup/WorkerRole1Instances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="WorkerRole1" generation="1" functional="0" release="0" software="D:\AURORA\Repos\PGITIC\ACS_Sensores\ACS_Sensores\csx\Release\roles\WorkerRole1" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaWorkerHost.exe " memIndex="-1" hostingEnvironment="consoleroleadmin" hostingEnvironmentVersion="2">
            <settings>
              <aCS name="APPINSIGHTS_INSTRUMENTATIONKEY" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;WorkerRole1&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;WorkerRole1&quot; /&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/ACS_Sensores/ACS_SensoresGroup/WorkerRole1Instances" />
            <sCSPolicyUpdateDomainMoniker name="/ACS_Sensores/ACS_SensoresGroup/WorkerRole1UpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/ACS_Sensores/ACS_SensoresGroup/WorkerRole1FaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="WorkerRole1UpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="WorkerRole1FaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="WorkerRole1Instances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
</serviceModel>