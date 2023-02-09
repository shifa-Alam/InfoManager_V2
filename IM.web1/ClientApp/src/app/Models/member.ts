import { BaseEntity } from "./baseEntity";
import { MemberSkill } from "./memberSkill";

export class Member  extends BaseEntity{
  name: string = '';
  countryId: number=0;
  cityId: number=0 ;
  resume: string = '';
  dateOfBirth: any;
  memberSkills:MemberSkill[]=[];

  countryName: string = '';
  cityName?: string = '';
  languageSkills:string='';
}

