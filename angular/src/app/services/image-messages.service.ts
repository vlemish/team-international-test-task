import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
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

  getImageMessageById(id: number){
    return this.http.get<ImageMessage>(this._url + '/' + id);
  }

  addImageMessage(entity: FormData) {
    console.log(entity);
    return this.http.post<ImageMessage>(this._url, entity).pipe(
      map(img=>{
        img.type='img';
        return img;
      })
    );
  }

  deleteImageMessage(id: number) {
    return this.http.delete(this._url + '/' + id);
  }
}
