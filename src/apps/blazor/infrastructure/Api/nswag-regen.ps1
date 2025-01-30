# nswag-regen.ps1

# Set your OpenAPI spec file path (e.g., Swagger.json or OpenAPI.yaml)
$openApiSpec = "https://localhost:7000/swagger/v1/swagger.json"

# Set your output directory for generated code
$outputDir = "C:\Project2025\AXIA Projects\src\apps\blazor\infrastructure\Api"

# Set the NSwag command
$nswagCommand = "nswag openapi2csclient /input=$openApiSpec /output=$outputDir /classname=ApiClient"

# Run the NSwag command to generate the API client
Invoke-Expression $nswagCommand

Write-Host "API client generated successfully!"
