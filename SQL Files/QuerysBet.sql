SELECT a.local,a.visita,b.casa,b.cuota_local,b.cuota_empate,b.cuota_visita FROM bet_cab A 
   left join bet_det B ON A.idcab = B.idcab
   WHERE B.idcab IS NOT NULL

SELECT  RIGHT(B.idcab,2), A.idcab,
        A.local,
        A.visita,
        B.casa,
        B.cuota_local,
        B.cuota_empate,
        B.cuota_visita 
FROM bet_cab A 
LEFT JOIN bet_det B ON A.idcab = B.idcab
WHERE B.idcab IS NOT NULL
GROUP BY  RIGHT(A.idcab,2),A.local,A.visita,B.casa,B.cuota_local,B.cuota_empate,B.cuota_visita 
HAVING COUNT (*)>1