'use client'
import React, { useEffect } from 'react';

export default function Error({ error, reset }: any) {

    useEffect(() => {
        console.log(error)
    }, [error]);
    
    return (
         <div className="text-red-500">
      <h1 className="text-2xl font-bold">Error</h1>
      
      <div className="border border-dashed border-red-500 p-4">
        <p>Alguma coisa deu errado..</p>
      </div>
    </div>
    )
}