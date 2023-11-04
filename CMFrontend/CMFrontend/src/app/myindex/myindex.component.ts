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
  //contractStages!: IContractStage[];

  constructor(private http: HttpClient/*, @Inject('BASE_URL') baseUrl: string*/) {
    //this.contracts = await this.httpClient.get<IContract[]>('/api/Contracts/GetContracts').toPromise();
    //this.getContracts();

    //http.get<Contract[]>('/api/Contracts/GetContracts').subscribe(result => {
    //  this.contracts = result;
    //}, error => console.error(error));

    this.getContracts();
    this.getContractStages();
    //let dasf = 0;
  }

  getContracts() {
    this.http.get<Contract[]>('/api/Contracts/GetContracts').subscribe(result => {
      this.contracts = result;
    });
    //node fetch module is loaded to be able to make use of fetch function
    //let fds = await fetch('/api/Contracts/GetContracts');

    //let dgsdg = await this.http.get('/api/Contracts/GetContracts').toPromise();

    //let fdf = 0;
  }

  getContractStages() {
    this.http.get<ContractStage[]>('/api/Contracts/GetContractStages').subscribe(result => {
      this.contractStages = result;
    });
  }

}

/*export interface Contract {
  contractCode: string;
  contractName: string;
  client: string;
}*/
