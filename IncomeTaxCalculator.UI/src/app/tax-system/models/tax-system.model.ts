import { TaxBandModel } from "./tax-band.model";

export class TaxSystemModel {
    constructor(
        public id: number,
        public name: string,
        public bands: TaxBandModel[]
    ) { }
}
