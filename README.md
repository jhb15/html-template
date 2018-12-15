
# Environment Variables

## Required Keys (All Environments)

| Environment Variable | Default | Description |
|-|-|-|
| ASPNETCORE_ENVIRONMENT | Production | Runtime environment, should be 'Development', 'Staging', or 'Production'. |
| ConnectionStrings__LayoutServiceContext | N/A | MariaDB connection string. |
| LayoutService__ClientId | N/A | Gatekeeper client ID. |
| LayoutService__ClientSecret | N/A | Gatekeeper client secret. |
| LayoutService__GatekeeperUrl | N/A | Gatekeeper URL. |


## Required Keys (Production + Staging Environments)
In addition to the above keys, you will also require:

| Environment Variable | Default | Description |
|-|-|-|
| Kestrel__Certificates__Default__Path | N/A | Path to the PFX certificate to use for HTTPS. |
| Kestrel__Certificates__Default__Password | N/A | Password for the HTTPS certificate. |
| LayoutService__ReverseProxyHostname | http://nginx | The internal docker hostname of the reverse proxy being used. |
| LayoutService__PathBase | /layout-service | The pathbase (name of the directory) that the app is being served from. |
