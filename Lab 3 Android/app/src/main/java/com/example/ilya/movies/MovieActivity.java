package com.example.ilya.movies;

import android.app.ActionBar;
import android.content.Intent;
import android.graphics.drawable.Drawable;
import android.graphics.drawable.ScaleDrawable;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.MenuItem;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.ilya.movies.entity.Movie;

import org.w3c.dom.Text;

import java.io.IOException;
import java.io.InputStream;

public class MovieActivity extends AppCompatActivity {

    private Movie movie;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_movie);

        Toolbar toolbar = findViewById(R.id.toolbar);
        TextView mTitle = toolbar.findViewById(R.id.toolbar_title);
        setSupportActionBar(toolbar);
        mTitle.setText(toolbar.getTitle());

        getSupportActionBar().setDisplayShowTitleEnabled(false);

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        Intent intent = getIntent();
        movie = (Movie) intent.getSerializableExtra("movie");

        Helper.LoadImageOnViewMain(movie,this,getAssets(),R.id.imgMovie);

        TextView txtTitle = findViewById(R.id.txtMovieTitle);
        txtTitle.setText(movie.Title);
        TextView txtRating = findViewById(R.id.txtMovieRating);
        txtRating.setText(movie.rating);
        TextView txtRelease = findViewById(R.id.txtMovieRelease);
        txtRelease.setText(movie.Release);
        TextView txtGenres = findViewById(R.id.txtMovieGenres);
        txtGenres.setText(movie.Genres);
        TextView txtDuration = findViewById(R.id.txtMovieDuration);
        txtDuration.setText(movie.Duration);
        TextView txtDescription = findViewById(R.id.txtMovieDescription);
        txtDescription.setText(movie.Description);
    }


    @Override
    public boolean onNavigateUp(){
        finish();
        return true;
    }

    public void onLinkClick(View view) {
        Intent intent = new Intent(MovieActivity.this, LinkActivity.class);
        intent.putExtra("link", movie.Link);
        startActivity(intent);
    }
}
