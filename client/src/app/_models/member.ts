import { Photo } from "./photo"

export interface Member{
    id:number
    username:string
    age:number
    photoUrl:string
    knowAs:string
    created:Date
    lastActive:Date
    gender:string
    introduction:string
    interests:string
    city:string
    country:string
    photos:Photo[]
}
