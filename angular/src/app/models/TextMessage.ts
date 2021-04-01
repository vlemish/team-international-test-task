import { Injectable } from '@angular/core';
import { IMessage } from './IMessage';

@Injectable()
export class TextMessage implements IMessage {
    private _id: number;
    private _type: string;
    private _creationTime: Date;
    private _content: string;

    /**
     *
     */
    constructor() {
        this._id = 0;
        this._type = "";
        this._creationTime = new Date();
        this._content = "";
    }


    public get id(): number {
        return this._id;
    }
    public set id(v: number) {
        this._id = v;
    }

    public get type(): string {
        return this._type;
    }
    public set type(v: string) {
        this._type = v;
    }

    public get creationTime(): Date {
        return this._creationTime;
    }
    public set creationTime(v: Date) {
        this._creationTime = v;
    }

    public get content(): string {
        return this._content;
    }
    public set content(v: string) {
        this._content = v;
    }

}