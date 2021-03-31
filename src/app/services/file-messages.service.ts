import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FileMessage } from '../models/FileMessage';
import { map, filter, switchMap } from 'rxjs/operators';
import { ImageMessage } from '../models/ImageMessage';

@Injectable({
  providedIn: 'root'
})
export class FileMessagesService {

  constructor(private http: HttpClient) { }

  //url to web api
  private _url: string = "https://localhost:44330/api/file-messages";

  getAllFileMessages() {
    return this.http.get<FileMessage[]>(this._url).pipe(
      map(response => {
        response.forEach(el => {
          el.type = 'file';
        })
        return response;
      })
    ).toPromise();
  }

  getAllImageMessages() {
    return this.http.get<ImageMessage[]>(this._url + '/imgs').pipe(
      map(response => {
        response.forEach(el => {
          el.type = 'img';
        })
        return response;
      })
    ).toPromise();
  }

  downloadFile(id: number) {
    return this.http.get(this._url + '/' + 'download' + '/' + id, { responseType: 'blob' }).pipe();
  }

  addFileMessage(entity: FormData) {
    console.log(entity);
    return this.http.post(this._url,
      entity
    );
  }

  deleteFileMessage(id: number) {
    return this.http.delete(this._url + '/' + id);
  }
}
