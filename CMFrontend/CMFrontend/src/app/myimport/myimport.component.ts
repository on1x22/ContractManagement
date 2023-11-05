import { Component, ErrorHandler } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'myimport-app',
  templateUrl: './myimport.component.html',
  styleUrls: ['./myimport.component.css']
})
export class MyimportComponent {
  fileName!: string;
  isCorrectFileType!: boolean;
  isCorrectUploaded!: boolean | null;
  formData!: FormData;
  file!: File;
  uploadMessage!: string;

  constructor(private http: HttpClient) { }

  async onFileSelected($event: any) {

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
    }
  }

  uploadFile() {
    return this.http.post("/Import/UploadFile", this.formData).subscribe(result => {
      this.uploadMessage = "Файл успешно загружен на сервер";
      this.isCorrectUploaded = true;
    }, error => {
      this.uploadMessage = (error as HttpErrorResponse).error;
      this.isCorrectUploaded = false;      
      console.log(error);
    });
  }
}
