import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, filter, switchMap } from 'rxjs/operators';
import { TextMessage } from '../models/TextMessage';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TextMessagesService {

  constructor(private http: HttpClient) { }

  //url to web api
  _url: string = "https://localhost:44330/api/text-messages";

  getAllTextMessages() {
    return this.http.get<TextMessage[]>(this._url).pipe(
      map(response=>{
        response.forEach(el=>{
          el.type='text';
        })
        return response;
      })
    ).toPromise();
  }

  getTextMessageById(id: number) {
    return this.http.get(this._url + '/' + id);
  }

  addTextMessage(entity: string) {
    let content = {
      content: entity
    };
    return this.http.post(this._url, content);
  }

  updateTextMessage(id: number, entity: string) {
    let content = {
      content: entity
    };
    return this.http.put(this._url + '/' + id, content);
  }

  deleteTextMessage(id: number) {
    return this.http.delete(this._url + '/' + id);
  }
}
