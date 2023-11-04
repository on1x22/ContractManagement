const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
      "/Import/UploadFile",
      "/api/Contracts/GetContracts",
      "/api/Contracts/GetContractStages",
    ],
    target: "https://localhost:5001",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
