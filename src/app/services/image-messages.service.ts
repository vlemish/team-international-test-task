import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, filter, switchMap } from 'rxjs/operators';
import { ImageMessage } from '../models/ImageMessage';

@Injectable({
  providedIn: 'root'
})
export class ImageMessagesService {

  constructor(private http: HttpClient) { }

  //url to web api
  private _url: string = "https://localhost:44330/api/img-messages";  

  getAllImageMessages() {
    return this.http.get<ImageMessage[]>(this._url).pipe(
      map(response => {
        response.forEach(el => {
          el.type = 'img';
        })
        return response;
      })
    ).toPromise();
  }

  addImageMessage(entity: FormData) {
    console.log(entity);
    return this.http.post(this._url,
      entity
    );
  }

  deleteImageMessage(id: number) {
    return this.http.delete(this._url + '/' + id);
  }
}
