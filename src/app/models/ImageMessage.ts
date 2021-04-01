import { Byte } from '@angular/compiler/src/util';
import { Injectable } from '@angular/core';
import { IMessage } from './IMessage';

@Injectable()
export class ImageMessage implements IMessage {
    private _id: number;
    private _type: string;
    private _creationTime: Date;
    private _data: Byte[];
    private _contentType: string;
    private _name : string;

    /**
     *
     */
    constructor() {
        this._id = 0;
        this._type = "";
        this._creationTime = new Date();
        this._data = [];
        this._contentType = "";
        this._name = "";
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

    public get data(): Byte[] {
        return this._data;
    }
    public set data(v: Byte[]) {
        this._data = v;
    }

    public get contentType(): string {
        return this._contentType;
    }
    public set contentType(v: string) {
        this._contentType = v;
    }

    public get name(): string {
        return this._name;
    }
    public set name(v: string) {
        this._name = v;
    }
}