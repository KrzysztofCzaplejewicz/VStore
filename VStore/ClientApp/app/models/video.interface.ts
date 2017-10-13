interface KeyValuePair {
    id: number;
    name: string;
}

export interface Video {
    id: number;
    title: string;
    price: number;
    quantity: number;
    genre: KeyValuePair;
}
export interface SaveVideo {
    id: number;
    title: string;
    price: number;
    quantity: number;
    genreId: number;
}