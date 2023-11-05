import { Component, ErrorHandler } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'myimport-app',
  templateUrl: './myimport.component.html',
  styleUrls: ['./myimport.component.css']
  //template: `<h3>Страница импорта</h3>`
})
export class MyimportComponent {
  fileName!: string;
  isCorrectFileType!: boolean;
  isCorrectUploaded!: boolean;
  formData!: FormData;
  file!: File;

  constructor(private http: HttpClient) { }

  onFileSelected($event: any) {

    this.file = $event.target.files[0];

    if (this.file) {

      this.fileName = this.file.name;

      if (this.fileName.endsWith(".xls") == false &&
        this.fileName.endsWith(".xlsx") == false) {
        this.isCorrectFileType = false;
        return;
      }

      this.isCorrectFileType = true;

      this.formData = new FormData();

      this.formData.append("fileExcel", this.file, this.fileName);

      //const upload$ = this.http.post("/api/thumbnail-upload", formData);

      //upload$.subscribe();
      let asda = 123;
    }
  }

  uploadFile() {
    const httpOptions = {
      headers: new HttpHeaders({
        //'Content-Type': 'multipart/form-data',
        //'Accept': 'application/json'
      })
    };

    // Взято здесь https://blog.angular-university.io/angular-file-upload/
    //const upload = this.http.post("https://localhost:7203/api/Import/UploadFile", this.formData, httpOptions);
    /*const upload =*/ return this.http.post("/Import/UploadFile", this.formData/*, httpOptions*/).subscribe(result => {
      // do something, if upload success
      let str = result;
      console.log("ok " + result);
      this.isCorrectUploaded = true;
    }, error => {
      if (error instanceof HttpErrorResponse && (error as HttpErrorResponse).status == 200)
      {
        this.isCorrectUploaded = true;
      }
      if (error instanceof HttpErrorResponse && (error as HttpErrorResponse).status == 500) {
        this.isCorrectUploaded = false;
      }
      console.log("ok " + error);
    }
    );



    //upload.subscribe();

    let asda = 123;
  }
}
