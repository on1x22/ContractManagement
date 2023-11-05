import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Contract } from '../model/Contract';
import { ContractStage } from '../model/ContractStage';

@Component({
  selector: 'myindex-app',
  templateUrl: './myindex.component.html',
  styleUrls: ['./myindex.component.css']
})
export class MyindexComponent {
  contracts!: Contract[];
  contractStages!: ContractStage[];

  constructor(private http: HttpClient) {
    this.getContracts();
    this.getContractStages();
  }

  getContracts() {
    this.http.get<Contract[]>('/api/Contracts/GetContracts').subscribe(result => {
      this.contracts = result;
    });
  }

  getContractStages() {
    this.http.get<ContractStage[]>('/api/Contracts/GetContractStages').subscribe(result => {
      this.contractStages = result;
    });
  }

}
