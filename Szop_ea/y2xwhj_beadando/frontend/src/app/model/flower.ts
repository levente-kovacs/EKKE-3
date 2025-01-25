import { Meaning } from "./meaning";

export class Flower {
  _id: string = '';
  name: string = '';
  anniversary: string = '';
  month: number = 0;
  when: Date = new Date();
  meanings: Meaning[] = [];
}
