import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { MyindexComponent } from './myindex/myindex.component';
import { MyimportComponent } from './myimport/myimport.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

const appRoutes: Routes = [
  { path: 'Contracts/Index', component: MyindexComponent },
  { path: 'Contracts/Import', component: MyimportComponent },
  {
    path: '**',
    redirectTo: '/Contracts/Index',
    pathMatch: 'full'
  }
];

@NgModule({
  declarations: [
    AppComponent,
    MyindexComponent,
    MyimportComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    NgbModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
