package com.example.ilya.movies;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;

import com.example.ilya.movies.entity.Movie;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity {

    private List<Movie> movies;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = findViewById(R.id.toolbar);
        TextView mTitle = toolbar.findViewById(R.id.toolbar_title);
        setSupportActionBar(toolbar);
        mTitle.setText(toolbar.getTitle());
        getSupportActionBar().setDisplayShowTitleEnabled(false);

        String json = getJson();
        movies = getMovies(json);
        fillTable(movies);
    }

    private String getJson(){
        String json = null;
        try {
            json = convertStreamToString(getAssets().open("movies.json"));
        } catch (Exception e) {
            e.printStackTrace();
        }
        return json;
    }

    private List<Movie> getMovies(String json)
    {
        List<Movie> movies = new ArrayList<>();
        try {
            JSONObject jsonObject = new JSONObject(json);
            JSONArray jsonArray = jsonObject.getJSONArray("Movies");
            for (int i = 0; i<jsonArray.length(); i++){
                JSONObject obj = jsonArray.getJSONObject(i);
                Movie movie = new Movie();
                movie.Title = obj.getString("Title");
                movie.Duration = obj.getString("Duration");
                movie.rating = obj.getString("rating");
                movie.Genres = obj.getString("Genres");
                movie.Link = obj.getString("Link");
                movie.Path = obj.getString("Path");
                movie.Release = obj.getString("Release");
                movie.Description = obj.getString("Description");
                movies.add(movie);
            }
        } catch (JSONException e) {
            e.printStackTrace();
        }
        return movies;
    }


    private void fillTable(final List<Movie> movies){
        final TableLayout tableLayout = findViewById(R.id.mainTable);
        for(int i = 0; i < movies.size() ; i++) {
            LayoutInflater layoutInflater = this.getLayoutInflater();
            TableRow tableRow = new TableRow(getBaseContext());
            layoutInflater.inflate(R.layout.row,tableRow);

            Helper.LoadImageOnViewRow(movies.get(i),getAssets(),tableRow, R.id.movieImage);

            TextView txtMovieName = tableRow.findViewById(R.id.txtMovieName);
            txtMovieName.setText(movies.get(i).Title);
            TextView txtDescription = tableRow.findViewById(R.id.txtDescription);
            txtDescription.setText(movies.get(i).Description);
            TextView txtRating = tableRow.findViewById(R.id.txtRating);
            txtRating.setText(movies.get(i).rating);

            tableRow.setOnClickListener(new View.OnClickListener(){
                @Override
                public void onClick(View v) {
                    // Current Row Index
                    int rowIndex = tableLayout.indexOfChild(v);
                    // Do what you need to do.

                    Intent intent = new Intent(MainActivity.this, MovieActivity.class);
                    intent.putExtra("movie", movies.get(rowIndex));
                    startActivity(intent);
                }
            });

            tableLayout.addView(tableRow);
        }
    }

    private String convertStreamToString(InputStream is) throws Exception {
        BufferedReader reader = new BufferedReader(new InputStreamReader(is));
        StringBuilder sb = new StringBuilder();
        String line;
        while ((line = reader.readLine()) != null) {
            sb.append(line);
        }
        reader.close();
        return sb.toString();
    }



}
