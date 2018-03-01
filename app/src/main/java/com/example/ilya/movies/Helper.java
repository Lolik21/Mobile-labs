package com.example.ilya.movies;

import android.content.res.AssetManager;
import android.graphics.drawable.Drawable;
import android.view.View;
import android.widget.ImageView;

import com.example.ilya.movies.entity.Movie;

import java.io.IOException;
import java.io.InputStream;

/**
 * Created by Ilya on 26.02.2018.
 */

public class Helper {
    public static void LoadImageOnViewRow(Movie movie, AssetManager assertManager, View view, int resourceId){
        try {
            InputStream inputStream = assertManager.open(movie.Path + ".jpg");
            Drawable d = Drawable.createFromStream(inputStream, null);
            ImageView imageView = view.findViewById(resourceId);
            imageView.setImageDrawable(d);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static void LoadImageOnViewMain(Movie movie, MovieActivity movieActivity, AssetManager assertManager, int resourceId){
        try {
            InputStream inputStream = assertManager.open(movie.Path + ".jpg");
            Drawable d = Drawable.createFromStream(inputStream, null);
            ImageView imageView = movieActivity.findViewById(resourceId);
            imageView.setImageDrawable(d);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
