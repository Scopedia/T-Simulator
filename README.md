# T-Simulator

ETS2 tarzi 3D tren kariyer oyunu. Game Development dersi donem projesi (Unity 6, URP, C#).

Yuk ve yolcu tasi, para kazan, daha guclu lokomotif ve daha cok vagon al;
buharlidan dizele, oradan elektrikliye gec.

## Veri yapilari (hepsi elle yazildi, hazir koleksiyon yok)

| Oyunda | Yapi | Sinif |
|---|---|---|
| Vagon baglama, ekleme, birakma, ters cevirme | Cift yonlu bagli liste | `DoublyLinkedList`, `TrainChain` |
| Peron sirasi, is bildirimleri | Dairesel kuyruk | `RingQueue` |
| Ray onarimi / dosemede geri al, menu geri | Stack + Command | `ArrayStack`, `TrackEditHistory` |
| Son 10 saniyeyi geri sarma | Ring buffer | `RingBuffer` |
| Is panosu, magaza, siralamalar | Insertion / Merge / Quick Sort | `Sorting` |
| Acil isler, zamanli olaylar | Min-heap | `MinHeap` |
| GPS: en hizli rota | BFS + Dijkstra | `RoutePlanner` |

## Klasor yapisi

```
Assets/_Project/
  Art/Models/          Blender'da uretilen low-poly modeller (FBX)
  Scripts/Collections/ TSim.Collections  - saf C#, Unity'ye bagimli degil
  Scripts/Simulation/  TSim.Simulation   - saf C#, oyun mantigi
  Scripts/Runtime/     TSim.Runtime      - MonoBehaviour'lar
  Tests/EditMode/      TSim.Tests.EditMode
```

Bagimlilik yalnizca asagi dogru: Runtime -> Simulation -> Collections.

## Kurallar

- Oyun kodunda `Stack`, `Queue`, `LinkedList`, `PriorityQueue`, `List.Sort`, `Array.Sort`, `OrderBy` kullanilmaz.
- `Update` icinde `new`, LINQ, boxing ve string birlestirme yok.
- Alanlar `[SerializeField] private`; public alan yok.
- Her koleksiyon unit test ve Big-O notuyla gelir.
